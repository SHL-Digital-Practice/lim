declare global {
  interface Window {
    chrome: {
      webview: {
        addEventListener: (
          message: string,
          handler: (args: unknown) => void
        ) => void;
        removeEventListener: (message: string, handler: () => void) => void;
        postMessage(message: string | object);
        hostObjects: {};
      };
    };
  }
}

export {};
