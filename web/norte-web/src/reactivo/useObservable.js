import { useEffect, useState } from 'react'

/**
 * Conecta un Observable de RxJS con React: el componente se vuelve a dibujar
 * cada vez que el flujo emite un valor nuevo, y cancela la suscripción al desmontarse.
 * Base del paradigma reactivo (responsable: Mauricio).
 */
export function useObservable(observable$, valorInicial) {
  const [valor, setValor] = useState(valorInicial)

  useEffect(() => {
    const suscripcion = observable$.subscribe(setValor)
    return () => suscripcion.unsubscribe()
  }, [observable$])

  return valor
}
