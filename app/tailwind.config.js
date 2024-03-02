/** @type {import('tailwindcss').Config} */
export default {
  content: ["./node_modules/flowbite/**/*.{js,ts}"],
  theme: {
    extend: {},
  },
  plugins: [require("flowbite/plugin")],
};
