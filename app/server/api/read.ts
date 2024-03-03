import * as fs from "node:fs";

export default defineEventHandler(async (event) => {
  try {
    const query = getQuery(event);
    console.log("reading file:" + query.path);
    const filePath = query.path as string;
    if (!filePath) throw new Error("path is required");
    const data = await fs.promises.readFile(filePath, "utf-8");
    return data;
  } catch (error) {
    console.log("error reading file:" + error);
  }
});
