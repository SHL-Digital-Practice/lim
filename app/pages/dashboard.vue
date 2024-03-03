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
      const { data } = event;
      if (data.type == "loadObject") {
        const { path } = data;
        const { data: resourceToLoad } = await useFetch("/api/read", {
          query: { path },
        });
        console.log("resourceToLoad", resourceToLoad);
        if (resourceToLoad.value) loadObjects(resourceToLoad.value);
      }

      if (data.type == "unloadAll") {
        await viewer.unloadAll();
      }

      if (data.type == "speciesData") {
        console.log(event.data);
      }

      if (data.type == "removeAllSpecies") {
        console.log("removeAllSpecies");
      }
    });
  }
});
</script>
