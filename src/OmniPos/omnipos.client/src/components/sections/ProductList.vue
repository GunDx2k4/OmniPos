<script setup lang="ts">
    import { ref, onMounted } from 'vue'
    import type { Product } from '@/types/Product'

    const products = ref<Product[]>([])
    const isLoading = ref(false)
    const error = ref<string | null>(null)

    const fetchProducts = async () => {
      isLoading.value = true;
      try {
        const baseUrl = import.meta.env.VITE_API_BASE_URL || ''
        const response = await fetch(`${baseUrl}/api/v1/products`)

        if (!response.ok) throw new Error();

          products.value = await response.json();
      } catch (err) {
          console.error(err);
          error.value = "Disconected server!";
      } finally {
          isLoading.value = false;
      }
    };

    onMounted(() => {
    fetchProducts();
    });
</script>

<template>
  <div class="container mx-auto px-4 py-8">
    <h2 class="text-2xl font-bold mb-6 text-text">Product List</h2>

    <div v-if="isLoading" class="text-center py-10">
      <span class="text-primary animate-pulse">Loading ...</span>
    </div>

    <div v-else-if="error" class="text-center text-accent py-10">
      {{ error }}
    </div>

    <div v-else-if="products.length === 0" class="text-center text-text-muted py-10">
      No products available.
    </div>

    <div v-else class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
      <div v-for="product in products"
           :key="product.id"
           class="bg-background rounded-xl shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300 border border-primary ring-primary">
        <div class="p-5">
          <div class="flex justify-between items-start">
            <h3 class="font-bold text-lg text-text mb-2 line-clamp-1">
              {{ product.name }}
            </h3>
            <span class="text-xs font-medium px-2 py-1 bg-surface rounded text-text-muted">
              ID: {{ product.id }}
            </span>
          </div>

          <p class="text-text-mutedtext-sm mb-4 line-clamp-2">
            {{ product.description || 'No description available' }}
          </p>

          <div class="flex items-center justify-between mt-4 pt-4 border-t border-border">
            <span class="text-xl font-bold text-primary">
              ${{ product.price.toLocaleString() }}
            </span>
            <div class="text-sm">
              Stock: <span :class="product.stockQuantity > 0 ? 'text-accent' : 'text-primary'">{{ product.stockQuantity }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
