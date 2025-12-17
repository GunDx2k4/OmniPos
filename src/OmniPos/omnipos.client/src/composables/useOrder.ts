import { reactive, computed, watch } from 'vue'
import type { OrderItem } from '@/types/OrderItem'
import type { Product } from '@/types/Product'

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
  (newVal) => localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(newVal)),
  { deep: true }
)

export function useOrder() {

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

  return {
    orderState,
    addToOrder,
    increaseQty,
    decreaseQty,
    updateQty,
    removeItem,
    totalAmount,
    totalItems
  }
}