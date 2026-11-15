import { solicitar } from './clienteHttp.js'

// Una función por endpoint. Cada módulo crea su propio archivo <modulo>Api.js igual a este.
export const listarCategorias = (tipo) =>
  solicitar(tipo ? `/api/categorias?tipo=${tipo}` : '/api/categorias')
