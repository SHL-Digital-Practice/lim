import * as path from "node:path";
import * as fs from "node:fs";

export default defineEventHandler(async (event) => {
  const filePath = path.join(process.cwd(), "public", "test.obj");
  const data = await fs.promises.readFile(filePath, "utf-8");
  return data;
});
