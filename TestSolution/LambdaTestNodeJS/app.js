const log4js = require('log4js');
const logger = log4js.getLogger();
logger
log4js.configure({
    appenders: { console: { type: "console", layout: { type: "messagePassThrough" } } },
    categories: { default: { appenders: ["console"], level: "info" } },
});

exports.handler = function (event, context) {

    console.log(' console.log ', event);
    logger.info(" logger.error ", event);
    logger.error(" logger.error ", event);
    context.done(null, 'Hello World');  // SUCCESS with message
};
