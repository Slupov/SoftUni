function validateRequest (inputObject) {
    function validateMethodProperty (method) {
        let methodRegex = /^(POST|GET|DELETE|CONNECT)$/g;
        if (!methodRegex.exec(method)) {
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateUri (uri) {
        let uriRegex = /(^[a-zA-Z.0-9]+$|\*)/g;
        if (!uriRegex.exec(uri) || uri === '') {
            throw new Error('Invalid request header: Invalid URI');
        }
    }

    function validateVersion (version) {
        let versionRegex = /^(HTTP\/0\.9|HTTP\/1\.0|HTTP\/1\.1|HTTP\/2\.0)$/g;
        if (!versionRegex.exec(version)) {
            throw new Error('Invalid request header: Invalid Version');
        }
    }

    function validateMessage (message) {
        let messageRegex = /[<>\\&'"]/g;
        if (messageRegex.exec(message)) {
            throw new Error('Invalid request header: Invalid Message');
        }
    }

    function validateProperties (object) {
        if (!object.method) {
            throw new Error('Invalid request header: Invalid Method');
        } else if (!object.uri) {
            throw new Error('Invalid request header: Invalid URI');
        } else if (!object.version) {
            throw new Error('Invalid request header: Invalid Version');
        } else if (!object.message) {
            if (object.message !== '') {
                throw new Error('Invalid request header: Invalid Message');
            }
        }
    }

    validateProperties(inputObject);
    validateMethodProperty(inputObject.method);
    validateUri(inputObject.uri);
    validateVersion(inputObject.version);
    validateMessage(inputObject.message);

    return inputObject;
}
