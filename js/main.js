const functionAppUrl = '';

document.addEventListener('DOMContentLoaded', () => {
    updateVisitorCount();
});

const updateVisitorCount = async () => {

    try {

        const response = await fetch(functionAppUrl);

        console.log('Making an API call to function app url');

        const data = await response.json();
    
        document.getElementById('visitorCounter').innerText = data.count;

    } catch (error) {

        console.error('Calling function app api failed: ', error);
    }
}