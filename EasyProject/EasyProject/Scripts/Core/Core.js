
function showMessage(serverResult, successMessage) {
    let finalResult = serverResult;
    if (finalResult == null)
        finalResult = "ERRO|null";
    if (finalResult.Result)
        finalResult = finalResult.Result;

    if (finalResult === 'OK') {
        alertify.success(successMessage);
        return true;
    } else if (finalResult) {
        let splittedResult = finalResult.split('|');

        if (splittedResult[0] == 'ALERTA') {
            alertify.warning(splittedResult[1]); 
        } else if (splittedResult[0] == 'INFO') {
            alertify.message('Standard notification message.');
        } else if (splittedResult[0] == 'SUCCESSO') {
            alertify.success(splittedResult[1]); 
            return true;
        } else if (splittedResult[0] == 'OK') {
            alertify.success(splittedResult[1]);
            return true;
        } else if (splittedResult[0] == 'ERRO') {
            alertify.error(splittedResult[1]); 
        } else {
            alertify.error(splittedResult[0]); 
        }
    }

    return false;
}


function showInfoMessage(message, title, template, timeToClose) {
    showMessageCore(message, title, tipo_mensagem.INFO, template, timeToClose);
}

function showErrorMessage(message, title, template, timeToClose) {
    showMessageCore(message, title, tipo_mensagem.ERRO, template, timeToClose);
}

function showWarnMessage(message, title, template, timeToClose) {
    showMessageCore(message, title, tipo_mensagem.AVISO, template, timeToClose);
}

function showSuccessMessage(message, title, template, timeToClose) {
    showMessageCore(message, title, tipo_mensagem.SUCESSO, template, timeToClose);
}

function showMessageCore(message, title, type, template, timeToClose) {
    if (!message)
        return;


}

