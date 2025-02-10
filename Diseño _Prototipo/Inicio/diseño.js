document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.getElementById('search-input');
    const suggestionsDiv = document.getElementById('suggestions');
    const searchButton = document.getElementById('search-button');
    const resultsSection = document.getElementById('results');
   


    // Simulación de palabras disponibles en el diccionario
    const palabras = ["Abacá", "Abanico", "Bohío", "Caculeo", "Cuba", "Cultura", "Lexicografía", "Tesoro", "Idioma", "Ñañigo", "Jaba", "Majá", "Güije", "Apagar", "Aparecer", "Apartar", "Apabullante"];

    // Escuchar eventos en el input de búsqueda
    searchInput.addEventListener('input', () => {
        const inputText = searchInput.value.toLowerCase();
        const filteredPalabras = palabras.filter(palabra => palabra.toLowerCase().startsWith(inputText));

        if (inputText.length > 0 && filteredPalabras.length > 0) {
            // Mostrar solo las primeras 5 sugerencias
            const primeras5 = filteredPalabras.slice(0, 5);
            suggestionsDiv.innerHTML = primeras5
                .map(palabra => `<div class="suggestion-item" onclick="seleccionarPalabra('${palabra}')">${palabra}</div>`)
                .join('') +
                `<div class="suggestion-item ver-todos" onclick="verTodosResultados('${inputText}')">
                    <i class="fas fa-search"></i> Ver todos los resultados para "${inputText}"
                </div>`;

            suggestionsDiv.style.display = "block"; // Mostrar sugerencias
        } else {
            suggestionsDiv.style.display = "none"; // Ocultar sugerencias si no hay coincidencias
        }
    });

    // Seleccionar una palabra de las sugerencias
    window.seleccionarPalabra = function (palabra) {
        searchInput.value = palabra;
        suggestionsDiv.style.display = "none"; // Ocultar sugerencias
        buscarPalabra(palabra);
    };

  
    function realizarBusqueda() {
        const body = document.body;
        const sidebarRight = document.getElementById('sidebar-right');
        const mainContainerSections = document.querySelector('.main-container .sidebar-section');
      
        // Agrega la clase para cambiar estilos y activar la animación
        body.classList.add('busqueda-realizada');
      
        // Mueve las secciones al sidebar-right después de un pequeño retraso
        setTimeout(() => {
          sidebarRight.innerHTML = mainContainerSections.innerHTML;
        }, 500); // 500ms coincide con la duración de la animación
      }
      
      // Evento de búsqueda
      document.getElementById('search-button').addEventListener('click', () => {
        const termino = searchInput.value.trim();
        if (termino) {
          buscarPalabra(termino);
          realizarBusqueda();
        }
      });

  // Evento de búsqueda
  document.getElementById('search-button').addEventListener('click', realizarBusqueda);
    // Evento para ejecutar la búsqueda al presionar el botón
    searchButton.addEventListener('click', () => {
        const termino = searchInput.value.trim();
        if (termino) {
            buscarPalabra(termino);
            realizarBusqueda();
        }
    });
});
