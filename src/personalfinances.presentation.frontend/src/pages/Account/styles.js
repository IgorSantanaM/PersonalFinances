import { Link } from 'react-router-dom';
import styled from 'styled-components';



export const Container = styled.div`
  font-family: Arial, sans-serif;
  margin: 20px;
`;

export const Label = styled.label`
  font-weight: bold;
  color: #1a73e8; /* Blue color */
  display: block;
  margin-bottom: 5px;
`;

export const CheckboxWrapper = styled.div`
  display: flex;
  align-items: center;
  gap: 5px;
`;

export const InputWrapper = styled.div`
  display: flex;
  align-items: center;
  gap: 5px;
`;

export const Input = styled.input`
  background-color: #fffbcc; 
  border: 1px solid ${(props) => (props.error ? 'red' : '#ccc')};
  padding: 8px;
  width: 400px;
  box-sizing: border-box;
  outline: none;

  &:focus {
    border-color: ${(props) => (props.error ? 'red' : '#1a73e8')};
  }
`;

export const Previous = styled(Link)`
  display:flex;
    align-items: center;
    text-decoration: none;
    transition: opacity 0.2s;

    &:hover{
      opacity: 0.7;
    }
    div{
      text-align: right;
      margin-right: 10px;

      span{
        font-size: 12px;
        color: #999;
      }
    }
`;
export const Select = styled.select`
  background-color: #fffbcc;
  border: 1px solid #ccc;
  padding: 8px;
  width: 400px;
  box-sizing: border-box;
  outline: none;

  &:focus {
    border-color: #1a73e8;
  }
`;

export const ErrorMessage = styled.div`
  color: red;
  font-size: 12px;
  margin-top: 4px;
`;

export const CheckboxLabel = styled.label`
  font-size: 0.9rem;
  color: #333;
`;

export const Checkbox = styled.input.attrs({ type: "checkbox" })``;