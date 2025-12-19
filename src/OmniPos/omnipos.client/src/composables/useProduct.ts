import { ref } from 'vue'
import type { Product } from '@/types/Product'

const baseUrl = import.meta.env.VITE_API_BASE_URL || ''

export function useProduct() {
    const products = ref<Product[]>([])
    const isLoading = ref(false)
    const error = ref<string | null>(null)

    const fetchProducts = async () => {
        isLoading.value = true
        error.value = null

        try {
            const response = await fetch(`${baseUrl}/api/v1/products`)

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

    const updateProductStock = async () => {
        error.value = null

        try {
            const response = await fetch(`${baseUrl}/api/v1/products`)

            if (!response.ok) {
                throw new Error('Không thể tải danh sách món ăn.')
            }

            const data = await response.json()
            products.value = Array.isArray(data) ? data : (data.items || [])

        } catch (err: any) {
            console.error(err)
            error.value = err.message || 'Lỗi kết nối.'
        }
    }

    const getProductById = async (id: number) => {

    }

    return {
        products,
        isLoading,
        error,
        fetchProducts,
        updateProductStock,
        getProductById
    }
}