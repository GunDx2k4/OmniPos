<script setup lang="ts">
import { ref } from 'vue'
import { Dialog, DialogPanel } from '@headlessui/vue'
import { Bars3Icon, XMarkIcon } from '@heroicons/vue/24/outline'
import ThemeSwitcher from '@/components/ui/ThemeSwitcher.vue'

const navigation = [
    { name: 'Home', href: '/' },
    { name: 'Blog', href: '/blog' },
    { name: 'Projects', href: '/projects' },
]

const mobileMenuOpen = ref(false)
</script>

<template>
  <header class="absolute inset-x-0 top-0 z-50 text-text">
    <div class="py-6 flex justify-end">
      <ThemeSwitcher />
    </div>
  </header>
</template>
