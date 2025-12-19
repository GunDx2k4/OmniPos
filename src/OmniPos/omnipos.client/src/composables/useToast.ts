import { ref } from 'vue'

export type ToastType = 'success' | 'error' | 'warning' | 'info'

interface Toast {
  id: number
  message: string
  type: ToastType
  duration?: number
}

const toasts = ref<Toast[]>([])

export function useToast() {
  
  const remove = (id: number) => {
    const index = toasts.value.findIndex((t) => t.id === id)
    if (index !== -1) toasts.value.splice(index, 1)
  }

  const add = (message: string, type: ToastType = 'info', duration = 3000) => {
    const id = Date.now() + Math.random()
    
    toasts.value.push({ id, message, type, duration })

    if (duration > 0) {
      setTimeout(() => {
        remove(id)
      }, duration)
    }
  }

  const success = (msg: string, duration?: number) => add(msg, 'success', duration)
  const error = (msg: string, duration?: number) => add(msg, 'error', duration)
  const warning = (msg: string, duration?: number) => add(msg, 'warning', duration)
  const info = (msg: string, duration?: number) => add(msg, 'info', duration)

  return {
    toasts,
    add,
    remove,
    success,
    error,
    warning,
    info
  }
}