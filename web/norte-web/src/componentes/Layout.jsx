import { NavLink, Outlet } from 'react-router-dom'
import './Layout.css'

const SECCIONES = [
  { ruta: '/dashboard', nombre: 'Dashboard' },
  { ruta: '/movimientos', nombre: 'Movimientos' },
  { ruta: '/deudas', nombre: 'Deudas y pagos' },
  { ruta: '/presupuestos', nombre: 'Presupuestos' },
  { ruta: '/metas', nombre: 'Metas de ahorro' },
  { ruta: '/categorias', nombre: 'Categorías' },
]

export default function Layout() {
  return (
    <div className="layout">
      <aside className="layout__menu">
        <span className="layout__marca">Norte</span>
        <nav>
          {SECCIONES.map(({ ruta, nombre }) => (
            <NavLink key={ruta} to={ruta} className="layout__enlace">
              {nombre}
            </NavLink>
          ))}
        </nav>
      </aside>
      <main className="layout__contenido">
        <Outlet />
      </main>
    </div>
  )
}
