import { ref } from 'vue'
import type { Product } from '@/types/Product'

export function useProduct() {
  const products = ref<Product[]>([])
  const isLoading = ref(false)
  const error = ref<string | null>(null)

  const fetchProducts = async () => {
    isLoading.value = true
    error.value = null
    
    try {
      const url = `/api/v1/products`

      const response = await fetch(url)

      if (!response.ok) {
        throw new Error('Không thể tải danh sách món ăn.')
      }

      const data = await response.json()
      products.value = Array.isArray(data) ? data : (data.items || [])

    } catch (err: any) {
      console.error(err)
      error.value = err.message || 'Lỗi kết nối.'
    } finally {
      isLoading.value = false
    }
  }

  const getProductById = async (id: number) => {
  }

  return {
    products,
    isLoading,
    error,
    fetchProducts,
    getProductById
  }
}