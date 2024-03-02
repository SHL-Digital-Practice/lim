<template>
  <div>
    catalogue
    {{ species }}
  </div>
</template>

<script setup lang="ts">
import type { Database } from "../types/supabase";

const db = useSupabaseClient<Database>();

const { data: species, pending } = useAsyncData("species", async () => {
  const { data, error } = await db.from("species").select("*");
  console.log(data);

  return data;
});
</script>

<style scoped></style>
