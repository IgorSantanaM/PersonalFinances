import styled from 'styled-components';

export const Header = styled.header`
  display: flex;
  align-items: center;
  padding: 10px;
  background-color: #f5f5f5;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
`;

export const Container = styled.div`
  padding: 20px;
`;

export const FormGroup = styled.div`
  margin-bottom: 15px;

  label {
    display: block;
    margin-bottom: 5px;
    font-weight: bold;
    color: #333;
  }

  input,
  select {
    width: 100%;
    padding: 10px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 5px;
    outline: none;
  }

  input.error {
    border-color: red;
  }

  span.error-text {
    color: red;
    font-size: 12px;
  }
`;

export const Categories = styled.div`
  display: flex;
  flex-wrap: wrap;
  gap: 10px;

  .category {
    display: flex;
    align-items: center;

    input {
      margin-right: 5px;
    }
  }

  .subcategory {
    margin-left: 20px;
  }
`;

export const Actions = styled.div`
  display: flex;
  justify-content: flex-end;
  gap: 10px;

  button {
    padding: 10px 20px;
    font-size: 16px;
    border: none;
    border-radius: 5px;
    cursor: pointer;

    &.cancel-btn {
      background-color: #ccc;
      color: #333;
    }

    &.save-btn {
      background-color: #4caf50;
      color: white;
    }
  }
`;
