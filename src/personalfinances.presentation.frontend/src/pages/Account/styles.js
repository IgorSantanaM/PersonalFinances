import styled from 'styled-components';

export const Card = styled.div`
  background: #fff;
  padding: 2rem;
  border-radius: 16px;
  box-shadow: 0 0 12px rgba(0, 0, 0, 0.08);
  max-width: 500px;
  margin: 2rem auto;
`;

export const Title = styled.strong`
  font-size: 1.5rem;
  font-weight: bold;
  color: #333;
`;

export const InputWrapper = styled.div`
  display: flex;
  align-items: center;
  border: 1px solid #ccc;
  border-radius: 8px;
  padding: 0.5rem;
  margin-top: 0.5rem;
  margin-bottom: 1rem;
  background: #fafafa;

  input {
    flex: 1;
    border: none;
    background: transparent;
    outline: none;
    font-size: 1rem;
    margin-left: 0.5rem;
  }
`;

export const BalancePrefix = styled.span`
  font-weight: 500;
  color: #888;
  margin-right: 4px;
`;

export const CurrencySymbol = styled.span`
  color: #444;
  font-weight: bold;
  margin-right: 4px;
`;

export const CheckboxWrapper = styled.div`
  display: flex;
  align-items: center;
  margin-top: 1rem;
`;

export const Checkbox = styled.input.attrs({ type: 'checkbox' })`
  margin-right: 0.5rem;
`;

export const CheckboxLabel = styled.label`
  font-size: 1rem;
  color: #333;
`;

export const SubmitButton = styled.button`
  width: 100%;
  padding: 0.75rem;
  margin-top: 2rem;
  font-size: 1rem;
  border: none;
  border-radius: 10px;
  background: #4caf50;
  color: white;
  cursor: pointer;
  transition: background 0.3s ease;

  &:hover {
    background: #43a047;
  }

  &:active {
    transform: scale(0.98);
  }
`;
