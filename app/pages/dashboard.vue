<template>
  <div
    class="bg-pink-200 flex items-center min-h-screen h-full justify-center p-6"
  >
    <div
      class="block w-full bg-white border border-gray-200 rounded-lg shadow hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700 h-[600px]"
    >
      <div class="w-full h-full bg-purple-500 rounded-lg" ref="container" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { Viewer as SpeckleViewer } from "@speckle/viewer";
import { onMounted, ref } from "vue";

const container = ref<HTMLElement | null>(null);

onMounted(() => {
  window.chrome.webview.addEventListener("message", (event: any) => {
    console.log(event);
  });
  const viewer = new SpeckleViewer(container.value!);
});
</script>

<style scoped></style>
