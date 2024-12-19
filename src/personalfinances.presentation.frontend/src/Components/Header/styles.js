import { Link } from 'react-router-dom';
import styled from 'styled-components';

export const Header = styled.header`
    background-color: whitesmoke;
    display: flex;
    align-items: center;
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