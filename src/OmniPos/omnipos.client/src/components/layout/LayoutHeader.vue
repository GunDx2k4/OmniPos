<script setup lang="ts">
import { useRoute } from 'vue-router'
import {
  HomeIcon,
  ArchiveBoxIcon,
  ClipboardDocumentListIcon,
  ChartBarIcon,
  UserIcon
} from '@heroicons/vue/24/outline'
import ThemeSwitcher from '@/components/ui/ThemeSwitcher.vue'
import logoUrl from '@/assets/images/logo.svg'

const route = useRoute()

const menuItems = [
  {
    name: 'Bán hàng',
    path: '/',
    icon: HomeIcon
  },
  {
    name: 'Kho hàng',
    path: '/inventory',
    icon: ArchiveBoxIcon
  },
  {
    name: 'Đơn hàng',
    path: '/orders',
    icon: ClipboardDocumentListIcon
  },
  {
    name: 'Báo cáo',
    path: '/reports',
    icon: ChartBarIcon
  },
]

</script>
<template>
  <header
    class="h-16 bg-surface border-b border-border px-4 md:px-6 flex items-center justify-between shadow-sm sticky top-0 z-50">

    <div class="flex items-center gap-8">
      <div class="flex items-center gap-2 cursor-pointer select-none">
        <img :src="logoUrl" alt="OmniPos Logo" class="w-8 h-8 object-contain" />
        <span class="font-bold text-xl text-primary tracking-tight hidden md:block">
          Omni<span class="text-white">Pos</span>
        </span>
      </div>

      <nav class="hidden md:flex items-center gap-1">
        <router-link v-for="item in menuItems" :key="item.path" :to="item.path"
          class="flex items-center gap-2 px-4 py-2 rounded-lg text-sm font-medium transition-all duration-200"
          active-class="bg-primary/10 text-primary" :class="[
            route.path === item.path ? '' : 'text-text-muted hover:text-primary hover:bg-primary/5'
          ]">
          <component :is="item.icon" class="w-5 h-5" />

          {{ item.name }}
        </router-link>
      </nav>
    </div>

    <div class="flex items-center gap-3">
      <ThemeSwitcher />

      <div class="h-6 w-px bg-border mx-1"></div>

      <button
        class="flex items-center gap-2 hover:bg-primary/5 p-1.5 pr-3 rounded-full transition-colors border border-transparent hover:border-primary/20">
        <div
          class="w-8 h-8 rounded-full bg-primary/10 flex items-center justify-center text-primary border border-primary/20">
          <UserIcon class="w-5 h-5" />
        </div>

        <div class="hidden lg:block text-left">
          <p class="text-xs font-bold text-text">Thu ngân 01</p>
          <p class="text-[10px] text-text-muted">Ca sáng</p>
        </div>
      </button>
    </div>
  </header>
</template>