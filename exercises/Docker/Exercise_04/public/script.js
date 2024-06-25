document.addEventListener('DOMContentLoaded', () => {
    const userForm = document.getElementById('userForm');
    const userList = document.getElementById('userList');
    const userIdInput = document.getElementById('userId');
    const nameInput = document.getElementById('name');
    const emailInput = document.getElementById('email');

    const apiUrl = '/users';

    const fetchUsers = async () => {
      const response = await fetch(apiUrl);
      const users = await response.json();
      userList.innerHTML = '';
      users.forEach(user => {
        const li = document.createElement('li');
        li.innerHTML = `
          ${user.name} (${user.email})
          <button onclick="editUser('${user._id}')">Edit</button>
          <button onclick="deleteUser('${user._id}')">Delete</button>
        `;
        userList.appendChild(li);
      });
    };

    const createUser = async (user) => {
      await fetch(apiUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
      });
      fetchUsers();
    };

    const updateUser = async (id, user) => {
      await fetch(`${apiUrl}/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
      });
      fetchUsers();
    };

    const deleteUser = async (id) => {
      await fetch(`${apiUrl}/${id}`, {
        method: 'DELETE',
      });
      fetchUsers();
    };

    window.editUser = (id) => {
      fetch(`${apiUrl}/${id}`)
        .then(response => response.json())
        .then(user => {
          userIdInput.value = user._id;
          nameInput.value = user.name;
          emailInput.value = user.email;
        });
    };

    userForm.addEventListener('submit', (e) => {
      e.preventDefault();
      const user = {
        name: nameInput.value,
        email: emailInput.value,
      };
      const id = userIdInput.value;
      if (id) {
        updateUser(id, user);
      } else {
        createUser(user);
      }
      userForm.reset();
    });

    fetchUsers();
  });
