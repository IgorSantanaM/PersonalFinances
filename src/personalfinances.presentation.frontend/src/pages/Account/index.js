import React, { useState } from 'react';
import { GrFormPrevious } from 'react-icons/gr';
import { Link } from 'react-router-dom';
import { Header, Container, FormGroup, Categories, Actions } from './styles';
import api from '../../services/api';

export default function Account() {
  const [name, setName] = useState('');
  const [accountType, setAccountType] = useState('Wallet');
  const [initialBalance, setInitialBalance] = useState('');
  const [categories, setCategories] = useState({
    salary: false,
    other: false,
    education: false,
    tuition: false,
  });
  const [reconcile, setReconcile] = useState(false);

  const handleCategoryChange = (category) => {
    setCategories((prev) => ({
      ...prev,
      [category]: !prev[category],
    }));
  };

  const isValidAmount = (amount) => {
    return !isNaN(amount);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const payload = {
      name,
      accountType,
      initialBalance: parseFloat(initialBalance),
      reconcile,
      categories: Object.keys(categories).filter((key) => categories[key]),
    };

    try {
      const response = await api.post('/account/create', payload);
      console.log('API response:', response.data);
      alert('Account added successfully!');
    } catch (error) {
      console.error('Error sending data to API:', error);
      alert('An error occurred. Please try again.');
    }
  };

  return (
    <>
      <Header>
        <Link to="/step/account">
          <GrFormPrevious size={25} color="black" />
        </Link>
        <strong>Add Account</strong>
      </Header>

      <Container>
        <form onSubmit={handleSubmit}>
          {/* Name Input */}
          <FormGroup>
            <label>Name</label>
            <input
              type="text"
              placeholder="Name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className={name ? '' : 'error'}
            />
            {!name && <span className="error-text">- Name required</span>}
          </FormGroup>

          {/* Account Type Dropdown */}
          <FormGroup>
            <label>Account type</label>
            <select
              value={accountType}
              onChange={(e) => setAccountType(e.target.value)}
            >
              <option value="Wallet">Wallet</option>
              <option value="Savings">Savings</option>
              <option value="Credit">Credit</option>
            </select>
          </FormGroup>

          {/* Initial Balance */}
          <FormGroup>
            <label>Initial balance</label>
            <input
              type="text"
              value={initialBalance}
              onChange={(e) => {
                const value = e.target.value;
                setInitialBalance(value);
                setReconcile(parseFloat(value) < 0);
              }}
              className={isValidAmount(initialBalance) ? '' : 'error'}
            />
            {!isValidAmount(initialBalance) && (
              <span className="error-text">- The amount is not a valid number</span>
            )}
          </FormGroup>

          {parseFloat(initialBalance) < 0 && (
            <FormGroup>
              <label>
                <input
                  type="checkbox"
                  checked={reconcile}
                  onChange={() => setReconcile(!reconcile)}
                />
                Reconcile
              </label>
            </FormGroup>
          )}

          {/* Categories */}
          <FormGroup>
            <label>No default categories have been selected</label>
            <Categories>
              <div className="category">
                <label>
                  <input
                    type="checkbox"
                    checked={categories.salary}
                    onChange={() => handleCategoryChange('salary')}
                  />
                  Salary
                </label>
              </div>
              <div className="category">
                <label>
                  <input
                    type="checkbox"
                    checked={categories.other}
                    onChange={() => handleCategoryChange('other')}
                  />
                  Other
                </label>
              </div>
              <div className="category">
                <label>
                  <input
                    type="checkbox"
                    checked={categories.education}
                    onChange={() => handleCategoryChange('education')}
                  />
                  Education
                </label>
                <div className="subcategory">
                  <label>
                    <input
                      type="checkbox"
                      checked={categories.tuition}
                      onChange={() => handleCategoryChange('tuition')}
                    />
                    Tuition
                  </label>
                </div>
              </div>
            </Categories>
          </FormGroup>

          {/* Buttons */}
          <Actions>
            <button type="button" className="cancel-btn">
              Cancel
            </button>
            <button type="submit" className="save-btn">
              Save
            </button>
          </Actions>
        </form>
      </Container>
    </>
  );
}
