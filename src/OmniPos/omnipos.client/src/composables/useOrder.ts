import { reactive, computed, watch } from 'vue'
import type { OrderItem } from '@/types/OrderItem'

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
  
  const addToOrder = (product: any) => {
    const existingItem = orderState.items.find((item) => item.productId === product.id)
    if (existingItem) {
      existingItem.quantity++
    } else {
      orderState.items.push({
        productId: product.id,
        productName: product.name,
        price: product.price,
        quantity: 1
      })
    }
  }

  const increaseQty = (productId: number) => {
    const item = orderState.items.find((item) => item.productId === productId)
    if (item) item.quantity++
  }

  const decreaseQty = (productId: number) => {
    const item = orderState.items.find((item) => item.productId === productId)
    if (item) {
      item.quantity--
      if (item.quantity <= 0) removeItem(productId)
    }
  }

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
    removeItem,
    totalAmount,
    totalItems
  }
}