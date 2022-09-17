import React, { FC } from 'react';
import styles from './DeskAllocation.module.css';

interface DeskAllocationProps {}

const DeskAllocation: FC<DeskAllocationProps> = () => (
  <div className={styles.DeskAllocation} data-testid="DeskAllocation">
    DeskAllocation Component
  </div>
);

export default DeskAllocation;
