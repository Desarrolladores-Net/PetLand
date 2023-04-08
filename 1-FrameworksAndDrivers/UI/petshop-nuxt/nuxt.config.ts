// https://nuxt.com/docs/api/configuration/nuxt-config

export default defineNuxtConfig({
    css: [
        "primevue/resources/themes/md-light-indigo/theme.css",
        "primevue/resources/primevue.css",
        "primeicons/primeicons.css"
    ],
	build: {
		transpile: ["primevue"]
	}
})
