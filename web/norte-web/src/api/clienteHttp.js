// Único punto de salida HTTP de la web. Todos los módulos llaman al API por aquí.
const URL_BASE = import.meta.env.VITE_API_URL ?? 'http://localhost:5147'
const CLAVE_TOKEN = 'norte.token'

export function guardarToken(token) {
  try {
    sessionStorage.setItem(CLAVE_TOKEN, token)
  } catch {
    // Navegación privada sin almacenamiento: la sesión dura solo mientras la pestaña esté abierta.
  }
}

function obtenerToken() {
  try {
    return sessionStorage.getItem(CLAVE_TOKEN)
  } catch {
    return null
  }
}

export async function solicitar(ruta, { metodo = 'GET', cuerpo } = {}) {
  const token = obtenerToken()
  const respuesta = await fetch(`${URL_BASE}${ruta}`, {
    method: metodo,
    headers: {
      'Content-Type': 'application/json',
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
    },
    body: cuerpo ? JSON.stringify(cuerpo) : undefined,
  })

  if (!respuesta.ok) {
    const detalle = await respuesta.json().catch(() => ({}))
    throw new Error(detalle.mensaje ?? `El servidor respondió ${respuesta.status}.`)
  }

  return respuesta.status === 204 ? null : respuesta.json()
}
