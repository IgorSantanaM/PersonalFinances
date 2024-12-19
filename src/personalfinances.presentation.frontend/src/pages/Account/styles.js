import styled from 'styled-components';

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

export const CheckboxLabel = styled.label`
  font-size: 0.9rem;
  color: #333;
`;

export const Checkbox = styled.input.attrs({ type: "checkbox" })``;