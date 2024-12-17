import React, { useState } from 'react';
import {GrFormPrevious} from 'react-icons/gr'

import {Header} from '../../Components/Header/styles'
import { Container, Label, Input, Previous, ErrorMessage, Select, InputWrapper, CheckboxWrapper, Checkbox, CheckboxLabel} from './styles';
import api from '../../services/api';

export default function Account() {
  const[name, setName] = useState('');
  const[isValid, setIsvalid] = useState(true);
  const[accountType, setAccountType] = useState('Wallet');
  const options  = ['Wallet', 'Credit Card', 'Savings'];
  const [initialBalance, setInitialBalance] = useState("");
  const [isReconcileChecked, setIsReconcileChecked] = useState(false);
  const accountTypeIndex = accountType.indexOf(accountType.trim());

  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = {
      name: name,
      accountType: accountTypeIndex,
      initialBalance: parseInt(initialBalance),
      reconcile: isReconcileChecked,
    };

    try {
      const response = await api.post("account/create", data);
      console.log("Data sent successfully:", response.data);
    } catch (error) {
      console.error("Error sending data:", error);
    }
  };  

  const handleInputChange = (e) => {
    const value = e.target.value;

    if (/^-?\d*$/.test(value)) {
      setInitialBalance(value);

      if (parseInt(value) < 0) {
        setIsReconcileChecked(false);
      }
    }
  };

  const handleBlur = () => {
    setIsvalid(name.trim() !== '');
  };

  return(
    <>
    <Header>
      <Previous to="/step/account" style={{ textDecoration: 'none' }}>
        <GrFormPrevious size={25} color="black" />
      </Previous>
      <strong>Add Account</strong>
    </Header>
  
    <Container>
        <Label htmlFor="name">Name</Label>

        <Input
        type="text"
        id="name"
        placeholder="Name"
        value={name}
        onChange={(e) => setName(e.target.value)}
        onBlur={handleBlur}
        className={`input-field ${!isValid ? 'input-error' : ''}`}
      />
      {!isValid && <ErrorMessage>- Name is required</ErrorMessage>}

      <Label htmlFor="accountType">Account Type</Label>

      <Select
      id="options"
      value={accountType}
      onChange={(e) => setAccountType(e.target.value)}>
        {options.map((option) => (<option 
        key={option} value={option}>
          {option}
        </option>))}
      </Select>

      <Label htmlFor="initialBalance">Initial Balance</Label>

      <InputWrapper>
        <span>+/-</span>
        <span>$</span>
        <Input
          type="text"
          value={initialBalance}
          onChange={handleInputChange}
          placeholder="Enter initial balance"
        />
      </InputWrapper>

      {initialBalance === "0" && (
        <ErrorMessage>- The amount is not a valid number</ErrorMessage>
      )}

      {parseInt(initialBalance) < 0 && (
        <CheckboxWrapper>
          <Checkbox
            checked={isReconcileChecked}
            onChange={() => setIsReconcileChecked((prev) => !prev)}
          />
          <CheckboxLabel>Reconcile</CheckboxLabel>
        </CheckboxWrapper>
      )}
      
      <button onClick={handleSubmit}>Submit</button>
    </Container>
    </>
  );
  }