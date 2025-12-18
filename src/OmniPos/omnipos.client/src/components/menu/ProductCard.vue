<script setup lang="ts">
import type { Product } from '@/types/Product'
import { formatCurrency } from '@/utils/formatters'
import { useOrder } from '@/composables/useOrder'

const props = defineProps<{
    product: Product
}>()

const { addToOrder } = useOrder()

const handleAddToCart = () => {
    if (props.product.stockQuantity === 0) return

    addToOrder(props.product)
}

const handleImageError = (e: Event) => {
    const target = e.target as HTMLImageElement;
    target.src = 'https://placehold.co/300x200?text=No+Image'
}

</script>

<template>
    <div @click="handleAddToCart"
        class="group relative bg-surface rounded-2xl shadow-sm border border-border overflow-hidden cursor-pointer hover:shadow-lg hover:-translate-y-1 transition-all duration-300">

        <div class="h-40 w-full overflow-hidden bg-border/30 relative">
            <img :src="product.imageUrl || 'https://via.placeholder.com/300x200?text=OmniPos'" :alt="product.name"
                @error="handleImageError"
                class="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500" />

            <div
                class="absolute inset-0 bg-black/20 opacity-0 group-hover:opacity-100 transition-opacity flex items-center justify-center">
                <span
                    class="bg-surface text-primary rounded-full p-2 shadow-lg transform scale-0 group-hover:scale-100 transition-transform">
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2.5"
                        stroke="currentColor" class="w-6 h-6">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
                    </svg>
                </span>
            </div>
        </div>

        <div class="p-4">
            <h3 class="font-bold text-text text-lg truncate mb-1" :title="product.name">
                {{ product.name }}
            </h3>

            <p class="text-xs text-text-muted line-clamp-2 mb-3 h-8">
                {{ product.description || 'Không có mô tả' }}
            </p>

            <div class="flex items-center justify-between">
                <span class="font-bold text-accent text-lg">
                    {{ formatCurrency(product.price) }}
                </span>


                <span v-if="product.stockQuantity === 0"
                    class="text-xs font-bold text-danger bg-danger/10 px-2 py-1 rounded border border-danger/30">
                    Hết hàng
                </span>

                <span v-if="product.stockQuantity > 0"
                    class="text-xs font-bold text-success bg-success/10 px-2 py-1 rounded border border-success/30">
                    còn lại {{ product.stockQuantity }}
                </span>
            </div>
        </div>
    </div>
</template>