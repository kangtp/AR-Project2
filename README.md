# AJOU NINJA (2023 IMP AR Project)

<div align="center">
  <img width="174" alt="AJOU NINJA Logo" src="https://github.com/user-attachments/assets/92f83050-b180-4167-9126-6378678c6173">
  <h2>👺 AJOU NINJA 👺</h2>
  <p><strong>"아주닌자"</strong>는 플레이어가 닌자가 되어 마을을 침략하는 몬스터들로부터 마을을 지키는 AR 기반 액션 게임입니다.</p>
</div>

## 목차
  - [개요](#개요)
  - [게임 설명](#게임-설명)
  - [게임 주요 기능](#게임-주요-기능)

## 개요
- **프로젝트 이름**: AJOU NINJA
- **프로젝트 기간**: 2023.04.01 ~ 2023.05.01
- **개발 엔진 및 언어**: Unity & C#
- **팀 구성**: TEAM4 (강현서, 박선준, 양경덕, Nitu Cristina) (개발 4)

## 게임 설명

| <img width="190" alt="시작 화면" src="https://github.com/user-attachments/assets/03911744-6493-40ab-ace6-f018dabede7f"> | <img width="190" alt="레벨 선택 화면" src="https://github.com/user-attachments/assets/52a879b7-5d57-49f8-a53d-1b67f3b7030b"> | <img width="190" alt="인게임 화면" src="https://github.com/user-attachments/assets/a5a0fd3c-1af7-4350-9929-8c02cd0bfe8e"> | <img width="190" alt="보스 화면" src="https://github.com/user-attachments/assets/5cbe26a6-48ac-4a6b-9030-242bed3084c6"> |
|:---:|:---:|:---:|:---:|
| 시작 화면 | 레벨 선택 화면 | 인게임 화면 | 보스 화면 |

**AJOU NINJA**는 증강 현실(AR) 기술을 활용하여, 플레이어가 실제 환경에서 닌자가 되어 마을을 침략하는 몬스터들과 싸우는 액션 게임입니다. 플레이어는 닌자의 무기와 스킬을 사용해 마을을 지키며, 점차적으로 강력해지는 적들과 맞서 싸워야 합니다.

- **주요 특징**:
  - **AR 기반 실감 전투**: Unity XR/AR Kit를 활용하여, 실제 주변 환경을 게임 배경으로 사용합니다. 플레이어는 현실 세계에서 직접 전투를 수행하는 듯한 몰입감을 경험할 수 있습니다. 디바이스를 움직여 적의 공격을 피할 수 있습니다.
  - **스테이지 기반 진행**: 게임은 여러 스테이지로 나뉘며, 각 스테이지는 일반 몬스터를 모두 제거하고 최종 보스를 처치하는 방식으로 진행됩니다. 레벨이 올라갈수록 도전적인 난이도를 제공합니다.
  - **몬스터 처치**: 일반 몬스터들은 스테이지 초반에 등장하여 플레이어를 공격하며, 이들을 모두 처치한 후 보스가 등장합니다. 보스 몬스터는 고유의 강력한 공격 패턴을 가지며, 플레이어는 이를 전략적으로 대응해야 합니다.

- **게임 목표**: 마을을 침략하는 모든 몬스터들을 물리치고, 최종 보스를 처치하여 마을의 평화를 되찾는 것이 게임의 최종 목표입니다.

## 게임 주요 기능

### 공격 시스템
- 화면을 터치하면 화면 중앙으로 표창을 날립니다. 적을 향해 표창을 날려 데미지를 줄 수 있습니다.<br/>

![제목 없는 동영상 - Clipchamp로 제작 (1)](https://github.com/user-attachments/assets/ec481f21-4e06-47e0-8ace-ef16baf45d02)


### 이미지 트래킹 및 스킬 공격
- **설명**: Unity XR/AR Kit를 사용하여 주변 이미지를 트래킹하고, 이를 기반으로 다양한 스킬을 사용할 수 있습니다. 플레이어는 특정 이미지를 인식해 3가지의 스킬을 사용할 수 있습니다. (이미지는 미리 XR/AR Kit에 지정되어야 합니다.)
- **사용 방법**: 플레이어가 이미지를 카메라에 인식시키면, 해당 이미지 위에 특정 파티클이 생성됩니다. 이 파티클을 클릭하면 해당하는 능력의 스킬 버튼이 활성화되며, 스킬을 사용할 수 있습니다.


| <img width="200" alt="트래킹 전" src="https://github.com/user-attachments/assets/bbf68d55-83b0-4beb-8dca-b2c5ea3ade8a"> | <img width="200" alt="트래킹 후" src="https://github.com/user-attachments/assets/dd6fd7fb-dafa-4c4d-ad3c-794cff005e78"> | <img width="200" alt="스킬 사용" src="https://github.com/user-attachments/assets/d468dccb-a848-4f13-b9a8-0c3db4791cb8"> |
|:---:|:---:|:---:|
| 트래킹 전 | 트래킹 후 | 스킬 사용 |

<br/>

|![image](https://github.com/user-attachments/assets/1200ce42-3053-4e35-bfc0-cb38551269a2)|![image](https://github.com/user-attachments/assets/d2eb017c-abde-46b0-b3a8-349aa813c7fb)|![image](https://github.com/user-attachments/assets/7bc4b565-292c-4182-81a7-6e9022dc3ace)|
|:---:|:---:|:---:|
| 불 이미지 인식 | 물 이미지 인식 | 전기 이미지 인식 |
- 특정 이미지를 인식하면 이미지 위에 원소 파티클이 생성되며, 파티클을 터치하면 해당하는 원소에 따라 화염, 물, 전기 마법 스킬을 활성화합니다.

### 보스 몬스터
- **설명**: 각 스테이지에는 고유의 보스가 존재하며, 보스마다 독특한 공격 패턴과 스킬을 구사합니다. 보스는 플레이어에게 다수의 투사체를 던지며, 고유 스킬로 플레이어를 압박합니다.

| <img width="200" alt="대지 보스" src="https://github.com/user-attachments/assets/e5f4f015-830b-416b-b5f8-2b825910dbcd"> | <img width="200" alt="얼음 보스" src="https://github.com/user-attachments/assets/30955e4d-d194-40bf-8e40-681a05df7ec4"> | <img width="200" alt="화염 보스" src="https://github.com/user-attachments/assets/6de87f54-03d0-4aa9-bc29-dfe3aa4319e5"> |
|:---:|:---:|:---:|
| 대지 보스 | 얼음 보스 | 화염 보스 |

---


