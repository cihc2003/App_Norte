import { useEffect, useState } from 'react'
import { listarCategorias } from '../../api/categoriasApi.js'

/**
 * Página de referencia: estado con useState, carga con useEffect y un manejador de
 * evento (onChange del filtro). Copien esta forma en cada módulo.
 */
export default function CategoriasPagina() {
  const [tipo, setTipo] = useState('')
  const [categorias, setCategorias] = useState([])
  const [error, setError] = useState(null)

  useEffect(() => {
    listarCategorias(tipo)
      .then((datos) => {
        setCategorias(datos)
        setError(null)
      })
      .catch((e) => setError(e.message))
  }, [tipo])

  const manejarCambioTipo = (evento) => setTipo(evento.target.value)

  return (
    <section>
      <h1>Categorías</h1>
      <label style={{ display: 'block', margin: 'var(--espacio-3) 0' }}>
        Mostrar{' '}
        <select value={tipo} onChange={manejarCambioTipo}>
          <option value="">Todas</option>
          <option value="Ingreso">Ingresos</option>
          <option value="Gasto">Gastos</option>
        </select>
      </label>

      {error && <p role="alert">No se pudieron cargar las categorías: {error}</p>}

      <ul>
        {categorias.map((categoria) => (
          <li key={categoria.id}>
            {categoria.nombre} ({categoria.tipo === 'Ingreso' ? 'ingreso' : 'gasto'})
          </li>
        ))}
      </ul>
    </section>
  )
}
