<template>
  <ClientOnly>
    <div class="bg-gray-100 flex flex-col items-center min-h-screen p-6">
      <div
        class="w-full bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700"
      >
        <DonutChart />
      </div>
      <Stats class="w-full" />
    </div>
  </ClientOnly>
</template>

<script setup lang="ts">
import DonutChart from "~/components/DonutChart.vue";

onMounted(async () => {
  if (window.chrome.webview) {
    window.chrome.webview.addEventListener("message", async (event: any) => {
      const message = JSON.parse(event.data);
      if (message.type == "loadObject") {
        const { path } = message;
        const { data: resourceToLoad } = await useFetch("/api/read", {
          query: { path },
        });
        console.log("resourceToLoad", resourceToLoad);
      }

      if (message.type == "unloadAll") {
      }

      if (message.type == "speciesData") {
        console.log("speciesData");
        const placedInstances = message.data;

        console.log("placedInstances", placedInstances);
      }

      if (message.type == "removeAllSpecies") {
        debugger;
        console.log("removeAllSpecies");
      }
    });
  }
});
</script>
