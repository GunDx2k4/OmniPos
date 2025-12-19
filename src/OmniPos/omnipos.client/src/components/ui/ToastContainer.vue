<script setup lang="ts">
import { useToast } from '@/composables/useToast'
import { 
  CheckCircleIcon, 
  ExclamationCircleIcon, 
  XCircleIcon, 
  InformationCircleIcon, 
  XMarkIcon 
} from '@heroicons/vue/24/outline'

const { toasts, remove } = useToast()

const getIcon = (type: string) => {
  switch (type) {
    case 'success': return CheckCircleIcon
    case 'error': return XCircleIcon
    case 'warning': return ExclamationCircleIcon
    default: return InformationCircleIcon
  }
}

const getStyles = (type: string) => {
  switch (type) {
    case 'success': return 'bg-success-lighter text-success-darker border-success/30 shadow-lg'
    case 'error': return 'bg-danger-lighter text-danger-foreground border-danger/30 shadow-lg'
    case 'warning': return 'bg-warning-lighter text-text border-warning/30 shadow-lg'
    default: return 'bg-info-lighter text-text border-info/30 shadow-lg'
  }
}
</script>

<template>
  <div class="fixed top-4 right-4 z-50 flex flex-col gap-2 w-full max-w-sm pointer-events-none">
    
    <TransitionGroup 
      enter-active-class="transform ease-out duration-300 transition"
      enter-from-class="translate-y-2 opacity-0 sm:translate-y-0 sm:translate-x-2"
      enter-to-class="translate-y-0 opacity-100 sm:translate-x-0"
      leave-active-class="transition ease-in duration-100"
      leave-from-class="opacity-100"
      leave-to-class="opacity-0"
    >
      <div 
        v-for="toast in toasts" 
        :key="toast.id"
        class="pointer-events-auto flex items-start gap-3 p-4 rounded-lg shadow-lg border border-opacity-50"
        :class="getStyles(toast.type)"
      >
        <component :is="getIcon(toast.type)" class="w-6 h-6 shrink-0" />

        <div class="flex-1 text-sm font-medium pt-0.5">
          {{ toast.message }}
        </div>

        <button @click="remove(toast.id)" class="shrink-0 hover:opacity-70 transition-opacity">
          <XMarkIcon class="w-5 h-5" />
        </button>
      </div>
    </TransitionGroup>

  </div>
</template>