import { Subject } from 'rxjs'

/**
 * Flujo de cambios financieros compartido por los módulos (responsable: Mauricio).
 *
 * Idea: cuando Movimientos registra un gasto, publica un cambio aquí. Presupuestos,
 * Dashboard y Metas están suscritos y se actualizan solos, sin que Movimientos sepa
 * que existen. Esa es la diferencia con el paradigma orientado a eventos: el evento
 * del botón inicia la acción, y el flujo reactivo propaga sus consecuencias.
 *
 * TODO (Mauricio): agregar los flujos derivados (por ejemplo, gastoPorCategoria$ con
 * map/scan) y las alertas de presupuesto.
 */
const cambios$ = new Subject()

export const publicarCambio = (cambio) => cambios$.next(cambio)

export const cambiosFinancieros$ = cambios$.asObservable()
