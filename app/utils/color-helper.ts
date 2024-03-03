import Rainbow from "rainbowvis.js";

export class ColorsHelper {
  static defaultColors: string[] = [
    "#134E4A",
    "#14B8A6",
    "#CCFBF1",
    "#FF6666",
    "#FF9999",
    "#FFE5E6",
  ];

  public static generateColors(numberOfColors: number): string[] {
    const colors: string[] = [];
    if (numberOfColors <= 0) return colors;

    const rainbow = new Rainbow();
    rainbow.setNumberRange(0, numberOfColors);
    rainbow.setSpectrumByArray(ColorsHelper.defaultColors);

    for (let i = 1; i <= numberOfColors; i++) {
      colors.push("#" + rainbow.colorAt(i));
    }

    return colors;
  }

  public static hexToRgba(hex: string, opacity: number) {
    return (
      "rgba(" +
      (hex = hex.replace("#", ""))
        ?.match(new RegExp("(.{" + hex.length / 3 + "})", "g"))
        ?.map(function (l) {
          return parseInt(hex.length % 2 ? l + l : l, 16);
        })
        .concat(isFinite(opacity) ? opacity : 1)
        .join(",") +
      ")"
    );
  }
}
