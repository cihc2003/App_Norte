import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// El puerto 5173 es el que permite la política CORS del API (Cors:OrigenSpa).
export default defineConfig({
  plugins: [react()],
  server: { port: 5173, strictPort: true },
})
