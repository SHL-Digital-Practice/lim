<template>
  <div
    class="bg-pink-200 flex items-center min-h-screen h-full justify-center p-6"
  >
    <div
      class="block w-full bg-white border border-gray-200 rounded-lg shadow hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700 h-[600px]"
    >
      <div class="w-full h-full rounded-lg" ref="container" />
    </div>
  </div>
</template>

<script setup lang="ts">
import {
  Viewer as SpeckleViewer,
  ObjLoader,
  DefaultViewerParams,
  CameraController,
  SelectionExtension,
} from "@speckle/viewer";
import { onMounted, ref } from "vue";

const container = ref<HTMLElement | null>(null);
let viewer: SpeckleViewer;

const params = DefaultViewerParams;
params.showStats = true;
params.verbose = true;

onMounted(async () => {
  viewer = new SpeckleViewer(container.value!, params);
  await viewer.init();
  viewer.createExtension(CameraController);
  viewer.createExtension(SelectionExtension);

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
    });
  }
});

async function loadObjects(resourceToLoad: string) {
  if (!viewer) return;

  await viewer.unloadAll();

  const loader = new ObjLoader(
    viewer.getWorldTree(),
    "rhino_things",
    resourceToLoad
  );

  await viewer.loadObject(loader, true);
}
</script>

<style scoped></style>
