import { reactive, computed, watch, ref } from 'vue'
import type { OrderItem } from '@/types/Order'
import type { Product } from '@/types/Product'

const baseUrl = import.meta.env.VITE_API_BASE_URL || ''

const orderState = reactive({
  items: [] as OrderItem[]
})

const LOCAL_STORAGE_KEY = 'omnipos_current_order'

const savedOrder = localStorage.getItem(LOCAL_STORAGE_KEY)
if (savedOrder) {
  try {
    orderState.items = JSON.parse(savedOrder)
  } catch {
    localStorage.removeItem(LOCAL_STORAGE_KEY)
  }
}

watch(
  () => orderState.items,
  (newVal) => {
    if (newVal.length === 0) {
      localStorage.removeItem(LOCAL_STORAGE_KEY)
    } else {
      localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(newVal))
    }
  },
  { deep: true }
)

export function useOrder() {
  const isSubmitting = ref(false)
  const error = ref<string | null>(null)
  const addToOrder = (product: Product) => {
    const existingItem = orderState.items.find((item) => item.productId === product.id)
    if (existingItem) {
      if (existingItem.quantity < existingItem.stockQuantity) {
        existingItem.quantity++
      }
    } else {
      orderState.items.push({
        productId: product.id,
        productName: product.name,
        price: product.price,
        quantity: 1,
        stockQuantity: product.stockQuantity
      })
    }
  }

  const increaseQty = (productId: number) => {
    const item = orderState.items.find((item) => item.productId === productId)
    if (item && item.quantity < item.stockQuantity) {
      item.quantity++
    }
  }

  const decreaseQty = (productId: number) => {
    const item = orderState.items.find((item) => item.productId === productId)
    if (item) {
      item.quantity--
      if (item.quantity <= 0) removeItem(productId)
    }
  }

  const updateQty = (productId: number, newQty: number) => {
    const item = orderState.items.find((i) => i.productId === productId);

    if (item) {

      if (newQty === 0) {
        removeItem(productId);
        return;
      }

      let validQty = Math.max(1, Math.floor(newQty))

      if (validQty > item.stockQuantity) {
        validQty = item.stockQuantity
      }

      item.quantity = validQty
    }
  };

  const removeItem = (productId: number) => {
    const index = orderState.items.findIndex((item) => item.productId === productId)
    if (index !== -1) orderState.items.splice(index, 1)
  }

  const totalAmount = computed(() => {
    return orderState.items.reduce((sum, item) => sum + (item.price * item.quantity), 0)
  })

  const totalItems = computed(() => {
    return orderState.items.reduce((total, item) => total + item.quantity, 0)
  })

  const clearCart = () => {
    orderState.items = []
  }
  const checkOut = async (paymentMethod: number) => {
    if (orderState.items.length === 0) return
    isSubmitting.value = true
    error.value = null

    try {
      const payload = {
        paymentMethod: paymentMethod,
        items: orderState.items.map(item => ({
          productId: item.productId,
          quantity: item.quantity
        }))
      }

      const response = await fetch(`${baseUrl}/api/v1/orders`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload)
      });

      const responseData = await response.json();

      if (!response.ok) {
        const customError: any = new Error(responseData.message || 'Lỗi API')
        customError.backendData = responseData
        throw customError
      }

      clearCart()
      return responseData.id || responseData.orderId;

    } catch (err: any) {
        console.error(err)
        error.value = `Không thể kết nối đến máy chủ. ${err.message}`
    } finally {
      isSubmitting.value = false
    }
  }

  return {
    orderState,
    addToOrder,
    increaseQty,
    decreaseQty,
    updateQty,
    removeItem,
    checkOut,
    isSubmitting,
    error,
    totalAmount,
    totalItems
  }
}