 document.addEventListener('DOMContentLoaded', () => {
    const convertBtn = document.getElementById('convertBtn');
    convertBtn.addEventListener('click', async () => {  
        const valueToConvert = document.getElementById('valueToConvert').value;
        if (!valueToConvert) {
            alert('Please enter a value to convert from!');
            return;
        }
        if (valueToConvert <= 0) {
            alert('Please enter a positive value!');
            return;
        }
        const fromUnit = document.getElementById('selectFrom').value;
        const toUnit = document.getElementById('selectTo').value;
        const response = await fetch(`/unitConverter/convert/value=${valueToConvert}&from=${fromUnit}&to=${toUnit}`);
        if (response.ok) {
            const resultValue = await response.json();
            document.getElementById('resultBox').value = resultValue.toFixed(2);
            document.getElementById('valueToConvert').value = '';
        }
        else {
            console.log(response);
        }
        
    });
 });
 


