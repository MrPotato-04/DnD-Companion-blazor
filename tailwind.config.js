/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor,html,razor.cs,css}'],
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {
            backgroundColor: {
                primary: '#1C1C1E',
            },
            textColor: {
                'primary-light': '#000000',
                black: "black",
                'primary-dark': '#fff',
                'secondary': '#6E6E6E',
            },
            colors: {
                primary: '#8B0000',
                secondary: '#2B2B2B',
                tertiary: '#FF4136',
                'accent-light': '#FFD700',
                'accent-dark': '#D4AF37',
                white: 'White',
                black: '#1A1A1A',
                gray: {
                    100: '#E1E1E1',
                    200: '#C8C8C8',
                    300: '#ACACAC',
                    400: '#919191',
                    500: '#6E6E6E',
                    600: '#404040',
                    900: '#212121',
                    950: '#141414',
                },
            },
        }

    },
    plugins: [],
}

