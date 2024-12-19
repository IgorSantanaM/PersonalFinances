import styled from "styled-components";


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

export const ErrorMessage = styled.div`
  color: red;
  font-size: 12px;
  margin-top: 4px;
`;