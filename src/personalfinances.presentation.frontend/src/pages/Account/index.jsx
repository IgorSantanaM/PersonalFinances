import React, { useState } from 'react';
import { GrFormPrevious } from 'react-icons/gr';

import {
  Label,
  Select,
  Container,
  Input,
  ErrorMessage,
} from '../../Components/Container/styles';
import {
  Header,
  Previous,
} from '../../Components/Header/styles';
import {
  InputWrapper,
  CheckboxWrapper,
  Checkbox,
  CheckboxLabel,
  SubmitButton,
  Card,
  Title,
  CurrencySymbol,
  BalancePrefix,
} from './styles';
import api from '../../services/api';

export default function Account() {
  const [name, setName] = useState('');
  const [isValid, setIsvalid] = useState(true);
  const [accountType, setAccountType] = useState('Wallet');
  const options = ['Wallet', 'Credit Card', 'Savings'];
  const [initialBalance, setInitialBalance] = useState('');
  const [isReconcileChecked, setIsReconcileChecked] = useState(false);
  const [accountTypeIndex, setAccountTypeIndex] = useState(accountType.indexOf(accountType));

  const handleAccountTypeChange = (e) => {
    const selectedAccountType = e.target.value;
    const selectedIndex = options.indexOf(selectedAccountType);
    setAccountType(selectedAccountType);
    setAccountTypeIndex(selectedIndex);
  };

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

  return (
    <>
      <Header>
        <Previous to="/step/account" style={{ textDecoration: 'none' }}>
          <GrFormPrevious size={25} color="black" />
        </Previous>
        <Title>Add Account</Title>
      </Header>

      <Container>
        <Card>
          <Label htmlFor="name">Name</Label>
          <Input
            type="text"
            id="name"
            placeholder="e.g. My Wallet"
            value={name}
            onChange={(e) => setName(e.target.value)}
            onBlur={handleBlur}
            className={`input-field ${!isValid ? 'input-error' : ''}`}
          />
          {!isValid && <ErrorMessage>- Name is required</ErrorMessage>}

          <Label htmlFor="accountType">Account Type</Label>
          <Select
            id="accountType"
            value={accountType}
            onChange={handleAccountTypeChange}
          >
            {options.map((option) => (
              <option key={option} value={option}>
                {option}
              </option>
            ))}
          </Select>

          <Label htmlFor="initialBalance">Initial Balance</Label>
          <InputWrapper>
            <BalancePrefix>+/-</BalancePrefix>
            <CurrencySymbol>$</CurrencySymbol>
            <Input
              type="text"
              value={initialBalance}
              onChange={handleInputChange}
              placeholder="0"
            />
          </InputWrapper>

          {initialBalance === "0" && (
            <ErrorMessage>- The amount is not a valid number</ErrorMessage>
          )}

          {parseInt(initialBalance) < 0 && (
            <CheckboxWrapper>
              <Checkbox
                checked={isReconcileChecked}
                onChange={() =>
                  setIsReconcileChecked((prev) => !prev)
                }
              />
              <CheckboxLabel>Reconcile</CheckboxLabel>
            </CheckboxWrapper>
          )}

          <SubmitButton onClick={handleSubmit}>
            Submit
          </SubmitButton>
        </Card>
      </Container>
    </>
  );
}
