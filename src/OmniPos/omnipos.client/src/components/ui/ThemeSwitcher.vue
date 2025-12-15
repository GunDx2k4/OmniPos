<script setup lang="ts">
  import { computed } from 'vue'
  import { useTheme, type Theme } from '@/composables/useTheme'
  import { Menu, MenuButton, MenuItems, MenuItem } from '@headlessui/vue'
  import {
    SunIcon,
    MoonIcon,
    ComputerDesktopIcon,
    ChevronDownIcon
  } from '@heroicons/vue/20/solid'

  const { theme, setTheme } = useTheme()

  const activeIcon = computed(() => {
    switch (theme.value) {
      case 'light': return SunIcon
      case 'dark': return MoonIcon
      default: return ComputerDesktopIcon
    }
  })

  const themeOptions: { value: Theme; label: string; icon: any }[] = [
    { value: 'light', label: 'Light', icon: SunIcon },
    { value: 'dark', label: 'Dark', icon: MoonIcon },
    { value: 'system', label: 'System', icon: ComputerDesktopIcon },
  ]
</script>

<template>
  <Menu as="div" class="relative inline-block text-left">

    <div>
      <MenuButton
        class="inline-flex w-full items-center justify-center gap-x-1.5 rounded-md px-3 py-2 text-sm font-semibold shadow-sm ring-1 ring-inset transition-colors bg-surface text-text-muted ring-border hover:bg-primary/10 hover:text-primary">
        <component :is="activeIcon" class="-ml-0.5 h-5 w-5" aria-hidden="true" />

        <ChevronDownIcon class="-mr-1 h-5 w-5" aria-hidden="true" />
      </MenuButton>
    </div>

    <transition enter-active-class="transition ease-out duration-100" enter-from-class="transform opacity-0 scale-95"
      enter-to-class="transform opacity-100 scale-100" leave-active-class="transition ease-in duration-75"
      leave-from-class="transform opacity-100 scale-100" leave-to-class="transform opacity-0 scale-95">
      <MenuItems
        class="absolute right-0 z-10 mt-2 w-36 origin-top-right rounded-md shadow-lg ring-1 focus:outline-none bg-surface ring-border">
        <div class="py-1">
          <MenuItem v-for="item in themeOptions" :key="item.value" v-slot="{ active }">
          <button @click="setTheme(item.value)"
            class="group flex w-full items-center px-4 py-2 text-sm transition-colors" :class="[
              active ? 'bg-primary/10 text-primary' : 'text-text-muted'
            ]">
            <component :is="item.icon" class="mr-3 h-5 w-5" :class="[
              (active || theme === item.value) ? 'text-primary' : 'text-text-muted'
            ]" aria-hidden="true" />

            <span :class="{ 'font-semibold text-primary': theme === item.value }">
              {{ item.label }}
            </span>
          </button>
          </MenuItem>
        </div>
      </MenuItems>
    </transition>
  </Menu>
</template>