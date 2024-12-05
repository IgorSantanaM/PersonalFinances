import React from 'react';
import Link from 'react-router-dom';
import { HeaderContainer, IconWrapper, Title, NextButton } from './styles';
import { MdHome } from 'react-icons/md';
import { FaBox } from 'react-icons/fa';

const Header = () => {
  return (
    <HeaderContainer>
      <IconWrapper>
        <MdHome size={50} />
        <FaBox size={25} style={{ position: 'absolute', top: '15px', left: '15px' }} />
      </IconWrapper>
      <Title to="">Welcome to Homeasy!</Title>
      <NextButton>Next</NextButton>
    </HeaderContainer>
  );
};

export default Header;
