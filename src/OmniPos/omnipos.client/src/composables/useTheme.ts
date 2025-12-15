import { ref, watch, onMounted } from 'vue'

export type Theme = 'light' | 'dark' | 'system'

export function useTheme() {
  const theme = ref<Theme>((localStorage.getItem('theme') as Theme) || 'system')

  const applyTheme = () => {
    const root = document.documentElement
    const isDark = theme.value === 'dark' || (theme.value === 'system' && window.matchMedia('(prefers-color-scheme: dark)').matches)

    if (isDark) {
      root.classList.add('dark')
    } else {
      root.classList.remove('dark')
    }
  }

  watch(theme, (newTheme) => {
    localStorage.setItem('theme', newTheme)
    applyTheme()
  })

  onMounted(() => {
    applyTheme()
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', applyTheme)
  })

  return {
    theme,
    setTheme: (newTheme: Theme) => (theme.value = newTheme)
  }
}
