import { Navigate, Route, Routes } from 'react-router-dom'
import Layout from './componentes/Layout.jsx'
import InicioSesionPagina from './modulos/autenticacion/InicioSesionPagina.jsx'
import CategoriasPagina from './modulos/categorias/CategoriasPagina.jsx'
import DashboardPagina from './modulos/dashboard/DashboardPagina.jsx'
import DeudasPagina from './modulos/deudas/DeudasPagina.jsx'
import MetasPagina from './modulos/metas/MetasPagina.jsx'
import MovimientosPagina from './modulos/movimientos/MovimientosPagina.jsx'
import PresupuestosPagina from './modulos/presupuestos/PresupuestosPagina.jsx'

// Cada módulo es dueño de su carpeta en src/modulos. Aquí solo se agregan rutas.
export default function App() {
  return (
    <Routes>
      <Route path="/iniciar-sesion" element={<InicioSesionPagina />} />
      <Route element={<Layout />}>
        <Route index element={<Navigate to="/dashboard" replace />} />
        <Route path="/dashboard" element={<DashboardPagina />} />
        <Route path="/movimientos" element={<MovimientosPagina />} />
        <Route path="/deudas" element={<DeudasPagina />} />
        <Route path="/presupuestos" element={<PresupuestosPagina />} />
        <Route path="/metas" element={<MetasPagina />} />
        <Route path="/categorias" element={<CategoriasPagina />} />
      </Route>
    </Routes>
  )
}
