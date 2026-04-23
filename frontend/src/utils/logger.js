const isDev = import.meta.env.DEV;

const logger = {
  info:  (...args) => isDev && console.info('[INFO]',  ...args),
  warn:  (...args) => isDev && console.warn('[WARN]',  ...args),
  error: (...args) => console.error('[ERROR]', ...args),
  debug: (...args) => isDev && console.debug('[DEBUG]', ...args),
};

export default logger;
