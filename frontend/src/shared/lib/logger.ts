const isDev = import.meta.env.DEV;

const logger = {
  info:  (...args: unknown[]): void => { isDev && console.info('[INFO]',  ...args); },
  warn:  (...args: unknown[]): void => { isDev && console.warn('[WARN]',  ...args); },
  error: (...args: unknown[]): void => { console.error('[ERROR]', ...args); },
  debug: (...args: unknown[]): void => { isDev && console.debug('[DEBUG]', ...args); },
};

export default logger;
