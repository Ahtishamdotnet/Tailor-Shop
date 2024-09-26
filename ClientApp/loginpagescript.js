function toggleSignup() {
    var loginSection = document.getElementById('login-section');
    var signupSection = document.getElementById('signup-section');
    if (signupSection.style.display === "none") {
        signupSection.style.display = "block";
        loginSection.style.display = "none";
    } else {
        signupSection.style.display = "none";
        loginSection.style.display = "block";
    }
}

async function login() {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var errorMessage = document.getElementById('error-message');

    if (!username || !password) {
        errorMessage.textContent = 'Please enter both username and password.';
        return;
    }

    try {
        const response = await fetch('https://localhost:7075/api/UserLogin/create', { // Replace with your actual API URL
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username: username, password: password })
        });

        if (response.ok) {
            alert('Login successful!');
            window.location.href = 'homepage.html'; // Redirect to the home page
        } else {
            errorMessage.textContent = 'Invalid username or password.';
        }
    } catch (error) {
        console.error('Error during login:', error);
        errorMessage.textContent = 'An error occurred. Please try again.';
    }
}

async function signup() {
    var username = document.getElementById('signup-username').value;
    var password = document.getElementById('signup-password').value;
    var signupErrorMessage = document.getElementById('signup-error-message');

    if (!username || !password) {
        signupErrorMessage.textContent = 'Please enter both username and password.';
        return;
    }

    try {
        const response = await fetch('https://localhost:7075/api/User/Create', { // Replace with your actual API URL
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username: username, password: password })
        });

        if (response.ok) {
            alert('Sign up successful! Please log in.');
            toggleSignup();
        } else {
            signupErrorMessage.textContent = 'Error: Unable to create account. Please try again.';
        }
    } catch (error) {
        console.error('Error during sign up:', error);
        signupErrorMessage.textContent = 'An error occurred. Please try again.';
    }
}