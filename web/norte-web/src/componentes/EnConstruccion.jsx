/** Marcador temporal: cada responsable lo reemplaza por la página real de su módulo. */
export default function EnConstruccion({ modulo, responsable, paradigmas }) {
  return (
    <section>
      <h1>{modulo}</h1>
      <p style={{ marginTop: 'var(--espacio-2)', color: 'var(--color-texto-suave)' }}>
        En construcción. Responsable: {responsable}. Paradigmas: {paradigmas}.
      </p>
    </section>
  )
}
