# norte-web

Interfaz de Norte: React 19 + Vite (JavaScript).

```bash
cp .env.example .env.local   # URL del API
npm install
npm run dev                  # http://localhost:5173
npm run build                # build de producción en dist/
npm run lint
```

## Estructura

```
src/
├── api/            Un archivo <modulo>Api.js por módulo. Todo pasa por clienteHttp.js.
├── componentes/    Piezas compartidas (Layout, EnConstruccion...).
├── estilos/        tokens.css (colores y fuentes del prototipo) y estilos globales.
├── reactivo/       Flujos RxJS compartidos y el hook useObservable (paradigma reactivo).
└── modulos/        Una carpeta por módulo; cada responsable trabaja solo en la suya.
```

`modulos/categorias/CategoriasPagina.jsx` es la página de referencia: copien su forma.

Reglas: la web solo presenta y pide datos. Los cálculos de dinero se hacen en el
backend, porque los números de JavaScript son de punto flotante.
