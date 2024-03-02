export default defineNuxtConfig({
  devtools: { enabled: true },
  modules: ["@nuxtjs/supabase", "nuxt-icon", "@nuxtjs/tailwindcss"],
  supabase: {
    redirect: false,
  },
});
